import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import { Button, Container, Dropdown, DropdownProps, Form, Segment } from "semantic-ui-react";

function IngredientForm(){
    const [ingredient, setIngredient] = useState({
        id: '',
        name: '',
        category: ''
    });

    const categoryOptions = [
        {key: "Category 1", value: "Category 1", text: "Category 1"},
        {key: "Category 2", value: "Category 2", text: "Category 2"},
        {key: "Category 3", value: "Category 3", text: "Category 3"},
    ]

    function handleSubmit(event: React.FormEvent<HTMLFormElement>){
        console.log(`Ingredient ID: ${ingredient.id}, Ingredient Name: ${ingredient.name}, Ingredient Category: ${ingredient.category}`)
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setIngredient({...ingredient, [name]: value}) 
    }

    function handleDropDownChange(event: SyntheticEvent<HTMLElement>, data: DropdownProps){
        setIngredient({...ingredient, [data.name]: data.value})
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