import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import { Button, Container, Dropdown, DropdownProps, Form, Segment } from "semantic-ui-react";
import { Ingredient } from "../../../app/models/ingredient";
import { RootState } from "../../../redux/store";
import { useDispatch, useSelector } from 'react-redux';
import { v4 as uuid } from 'uuid';
import { createIngredient, editIngredient } from "../../../redux/actions/ingredient/ingredientActions";
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

function IngredientForm(){
    const [ingredient, setIngredient] = useState({
        id: '',
        name: '',
        category: 0
    });
    let allIngredients: Ingredient[] | undefined = useSelector((state: RootState) => state.ingredients.ingredients)
    const dispatch = useDispatch()
    const categoryOptions = [
        {key: "1", value: 1, text: "Category 1"},
        {key: "2", value: 2, text: "Category 2"},
        {key: "3", value: 3, text: "Category 3"},
    ]

    function handleSubmit(event: React.FormEvent<HTMLFormElement>){
        event.preventDefault();
        
        if(ingredient){
            if(!allIngredients?.find(i => i.id === ingredient.id)){
                ingredient.id = uuid();
                dispatch(createIngredient(ingredient))
                sweetAlertFire(true);
            } else {
                dispatch(editIngredient(ingredient))
                sweetAlertFire(false);
            }
        }
    }    

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setIngredient({...ingredient, [name]: value}) 
    }

    function handleDropDownChange(event: SyntheticEvent<HTMLElement>, data: DropdownProps){
        setIngredient({...ingredient, [data.name]: data.value})
    }

    function sweetAlertFire(isNewRecipe: boolean){
        const MySwal = withReactContent(Swal)

        MySwal.fire({
        title: <p>Recipe Confirmed</p>,
        footer: 'Copyright 2018',
        didOpen: () => {
            // `MySwal` is a subclass of `Swal`
            //   with all the same instance & static methods
            MySwal.clickConfirm()
        }
        }).then(() => {
            if(isNewRecipe){
                return MySwal.fire(<p>Ingredient Added</p>)
            } else {
                return MySwal.fire(<p>Ingredient Updated</p>)
            }
        })
    }

    return(
        <Segment clearing>
            <Container>
                <Form onSubmit={handleSubmit}>
                    <Form.Input placeholder="Name" name='name' value={ingredient.name} onChange={handleInputChange} />
                    <Dropdown 
                        placeholder="Category" 
                        name="category"
                        value={ingredient.category}
                        fluid
                        search
                        selection
                        options={categoryOptions}
                        onChange={handleDropDownChange} 
                        />
                    <Button id="createIngredientsBtn" floated="right" positive type="submit" content="Submit" />
                </Form>
            </Container>
        </Segment>
    )
}

export default IngredientForm;