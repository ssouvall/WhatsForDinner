import React, { ChangeEvent, useState, useEffect } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { createRecipe, editRecipe, setFormOpenState, setRecipeDetails } from "../../../redux/actions/recipe/recipeActions";
import { RootState } from "../../../redux/store";
import { Link, useHistory } from "react-router-dom";
import SampleModal from "../../../app/layout/SampleModal";
import { v4 as uuid } from 'uuid';

export default function RecipeForm() {
    const dispatch = useDispatch()
    const history = useHistory()
    const [submitting, setSubmitting] = useState(false);
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
    }, [selectedRecipe])

    function handleLoading(submitting: boolean){
        setSubmitting(submitting);
        // dispatch(setButtonSubmittingState(submitting));
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        // setSubmitting(true);
        handleLoading(true);
        if(recipe){
            if(!allRecipes?.find(r => r.id === recipe.id)){
                recipe.id = uuid();
                dispatch(createRecipe(recipe))
            } else {
                dispatch(editRecipe(recipe))
            }
            console.log(recipe);
        }
        setTimeout(() => {
            handleLoading(false);
            dispatch(setFormOpenState(false, recipe))
            dispatch(setRecipeDetails(recipe.id));
        }, 1000)
        if(recipe){
            history.push(`/recipes/${recipe.id}`);
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setRecipe({...recipe, [name]: value}) 
    }

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
                <Button as={Link} to='/recipes' onClick={() => dispatch(setFormOpenState(false, recipe))} floated="right" type="submit" content="Cancel" />
            </Form>
        </Segment>
    )
}