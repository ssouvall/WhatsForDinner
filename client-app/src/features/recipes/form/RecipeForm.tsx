import React, { ChangeEvent, useState, useEffect, useCallback } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { createRecipe, editRecipe, setFormOpenState, setRecipeDetails } from "../../../redux/actions/recipe/recipeActions";
import { RootState } from "../../../redux/store";
import { Link, useHistory, Redirect } from "react-router-dom";
import SampleModal from "../../../app/layout/SampleModal";
import { v4 as uuid } from 'uuid';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

export default function RecipeForm() {
    const dispatch = useDispatch()
    const history = useHistory()
    const [submitting, setSubmitting] = useState(false);
    const [submitted, setSubmitted] = useState(false);
    let selectedRecipe: Recipe | undefined = useSelector((state: RootState) => state.recipes.recipe)
    let allRecipes: Recipe[] | undefined = useSelector((state: RootState) => state.recipes.recipes)

    const [recipe, setRecipe] = useState({
        id: '',
        name: '',
        category: '',
        description: '',
        instructions: ''
    });

    useEffect(() => {
        if (selectedRecipe !== undefined) setRecipe(selectedRecipe)
        if (submitted) {
            // if(selectedRecipe){
            //     history.push(`/recipes/${selectedRecipe.id}`);
            // }
        }
    }, [selectedRecipe, submitted, history])

    function handleLoading(submitting: boolean){
        setSubmitting(submitting);
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        event.stopPropagation();
        console.log(event.currentTarget)
        
        // handleLoading(true);
        if(recipe){
            if(!allRecipes?.find(r => r.id === recipe.id)){
                recipe.id = uuid();
                dispatch(createRecipe(recipe))
                sweetAlertFire(true);
                // dispatch(setRecipeDetails(recipe.id));
            } else {
                // dispatch(setFormOpenState(false, recipe));
                dispatch(editRecipe(recipe))
                sweetAlertFire(false);
                // dispatch(setRecipeDetails(recipe.id));
            }
        }
        history.push('/recipes');
        // handleLoading(false);
        // setSubmitted(true);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setRecipe({...recipe, [name]: value}) 
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
                return MySwal.fire(<p>Recipe Added</p>)
            } else {
                return MySwal.fire(<p>Recipe Updated</p>)
            }
        })
    }

    // if(!submitted){
        return (
            <Segment clearing>
                <Form onSubmit={handleSubmit} autoComplete='off' >
                    <Form.Input placeholder="Title" value={recipe.name} name='name' onChange={handleInputChange} />
                    <Form.TextArea placeholder="Description" value={recipe.description} name='description' onChange={handleInputChange} />
                    <Form.Input placeholder="Category" value={recipe.category} name='category' onChange={handleInputChange} />
                    <Form.TextArea placeholder="Instructions" value={recipe.instructions} name='instructions' onChange={handleInputChange} />
                    {/* <SampleModal 
                        submitting={submitting}
                        recipe={recipe}
                    /> */}
                    <Button loading={submitting} floated="right" positive type="submit" content="Submit" />
                    {/* <Button onClick={closeForm} floated="right" type="submit" content="Cancel" /> */}
                    {/* <Button as={Link} to='/recipes' onClick={() => dispatch(setFormOpenState(false, recipe))} floated="right" type="submit" content="Cancel" /> */}
                </Form>
            </Segment>
        )
    // } else {
    //     return (
    //         <Redirect to={`/recipes/${recipe.id}`} />
    //     )
    // }
    
}