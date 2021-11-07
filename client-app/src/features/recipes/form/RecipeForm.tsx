import React, { ChangeEvent, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";

interface Props {
    recipe: Recipe;
}

export default function ActivityForm({recipe}: Props) {

    // const initialState = SelectedRecipe ?? {
    //     id: '',
    //     name: '',
    //     category: '',
    //     description: '',
    //     instructions: ''
    // }

    // const [recipe, setRecipe] = useState(initialState);

    // function handleSubmit() {
    //     createOrEdit(recipe);
    // }

    // function handleInputChange(event: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLTextAreaElement>) {
    //     const {name, value} = event.target;
    //     setActivity({...recipe, [name]: value}) 
    // }

    return (
        <Segment clearing>
            <Form /*onSubmit={handleSubmit}*/ autoComplete='off' >
                <Form.Input placeholder="Title" value={recipe.name} name='title' /*onChange={handleInputChange}*/ />
                <Form.TextArea placeholder="Description" value={recipe.description} name='description' /*onChange={handleInputChange}*/ />
                <Form.Input placeholder="Category" value={recipe.category} name='category' /*onChange={handleInputChange}*/ />
                <Form.TextArea placeholder="Description" value={recipe.instructions} name='instructions' /*onChange={handleInputChange}*/ />
                <Button /*loading={submitting}*/ floated="right" positive type="submit" content="Submit" />
                <Button /*onClick={closeForm}*/ floated="right" type="submit" content="Cancel" />
            </Form>
        </Segment>
    )
}