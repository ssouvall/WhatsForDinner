import React from "react";
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";

interface Props {
    recipes: Recipe[];
    selectRecipe: (id: number) => void;
}

export default function RecipeList({recipes, selectRecipe}: Props) {
    return(
        <Segment>
            <Item.Group divided>
                {recipes.map((recipe) => (
                    <Item key={recipe.id}>
                        <Item.Content>
                            <Item.Header as='a'>{recipe.name}</Item.Header>
                            <Item.Description>
                                <div>{recipe.description}</div>
                                <div>{recipe.instructions}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={() => selectRecipe(recipe.id)} floated='right' content='View' color='blue' />
                                <Button 
                                    floated='right' 
                                    content='Delete' 
                                    color='red' 
                                />
                                <Label basic content={recipe.category}/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>     
            ))}
            </Item.Group>
        </Segment>
    );
}