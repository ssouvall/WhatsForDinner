import React, { ChangeEvent, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";

interface Props {
    recipe: Recipe | undefined;
    closeForm: () => void;
    createOrEdit: (recipe: Recipe) => void;
    submitting: boolean;
}

export default function ActivityForm({recipe: selectedRecipe, closeForm, createOrEdit, submitting}: Props) {

    const initialState = selectedRecipe ?? {
        id: 0,
        name: '',
        category: '',
        description: '',
        instructions: ''
    }

    const [recipe, setRecipe] = useState(initialState);

    function handleSubmit() {
        createOrEdit(recipe);
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
                <Button loading={submitting} floated="right" positive type="submit" content="Submit" />
                <Button onClick={closeForm} floated="right" type="submit" content="Cancel" />
            </Form>
        </Segment>
    )
}