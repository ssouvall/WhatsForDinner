import React, {useState, useEffect} from "react";
import { Button, Card, Image } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { setRecipeDetails, setFormOpenState } from '../../../redux/actions/recipe/recipeActions';
import { RootState } from "../../../redux/store";
import LoadingComponent from '../../../app/layout/LoadingComponents';
import { Link } from "react-router-dom"
import { IngredientListItem } from "../../../app/models/ingredientListItem";

export default function RecipeDetails(){
    const dispatch = useDispatch();
    const recipe: Recipe | undefined = useSelector((state: RootState) => state.recipes.recipe);
    const ingredientListItems: IngredientListItem[] | undefined = useSelector((state: RootState) => state.ingredientListItems.ingredientListItems)

    if(recipe && recipe.recipeId){
        console.log(recipe)
        return(
            <Card fluid>
                <Image src={`/assets/categoryImages/${recipe.category}.jpg`} />
                <Card.Content>
                <Card.Header>{recipe.name}</Card.Header>
                {/* <Card.Meta>
                    <span>{recipe.}</span>
                </Card.Meta> */}
                <Card.Description>
                    {recipe.description}
                </Card.Description>
                <Card.Description>
                    {recipe.instructions}
                </Card.Description>
                 <Card.Description>
                     <ul>
                    {ingredientListItems.map((item) => (
                        <li>{`${item.quantity} ${item.quantityUnit} ${item.name}`}</li>
                    ))}
                    </ul>
                </Card.Description>
                </Card.Content>
                <Card.Content extra>
                    <Button.Group widths='2'>
                        {/* <Button onClick={() => openForm(recipe.id)} basic color='blue' content='Edit' /> */}
                        {/* <Button onClick={cancelSelectRecipe} basic color='grey' content='Cancel' /> */}
                        <Button as={Link} to={`/manage/${recipe.recipeId}`} basic color='blue' content='Edit' />
                        <Button as={Link} to='/recipes' onClick={() => dispatch(setRecipeDetails(undefined))} basic color='grey' content='Cancel' />
                    </Button.Group>
                </Card.Content>
            </Card> 
        )
    } else {
        return <LoadingComponent content='Loading recipe' />
    }
}