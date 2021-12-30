import React from "react";
import { Button, Card, Image } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch } from 'react-redux';
// import { RootState } from "../../../redux/store";
// import { useEffect } from "react";
import { setRecipeDetails, setFormOpenState } from '../../../redux/actions/recipe/recipeActions';

interface Props {
    recipe: Recipe;
    cancelSelectRecipe: () => void;
    openForm: (id: number) => void;
}

export default function RecipeDetails({recipe, cancelSelectRecipe, openForm}: Props){
    const dispatch = useDispatch();
    // const recipe: Recipe = useSelector((state: RootState) => state.recipes.recipe)

    // useEffect(() => {
    //     getRecipeDetails(recipe.id);
    // }, [dispatch, recipe.id])

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
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths='2'>
                    {/* <Button onClick={() => openForm(recipe.id)} basic color='blue' content='Edit' /> */}
                    {/* <Button onClick={cancelSelectRecipe} basic color='grey' content='Cancel' /> */}
                    <Button onClick={() => dispatch(setFormOpenState(true, recipe))} basic color='blue' content='Edit' />
                    <Button onClick={() => dispatch(setRecipeDetails(undefined))} basic color='grey' content='Cancel' />
                </Button.Group>
            </Card.Content>
        </Card> 
    )
}