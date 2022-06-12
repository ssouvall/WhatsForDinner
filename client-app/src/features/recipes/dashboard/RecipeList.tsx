import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from "../../../redux/store";
import { useState, SyntheticEvent } from "react";
import { deleteRecipe, setFormOpenState, setRecipeDetails } from '../../../redux/actions/recipe/recipeActions';
import { Link } from "react-router-dom";
import { fetchIngredientListItemsByRecipe } from "../../../redux/actions/ingredientListItem/ingredientListItemActions";

function RecipeList() {
    const dispatch = useDispatch()
    const [submitting, setSubmitting] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState('');
    const recipes: Recipe[] = useSelector((state: RootState) => state.recipes.recipes)

    function setRecipeToShow(e: SyntheticEvent<HTMLButtonElement>, recipeId: string){
        console.log(e.currentTarget)
        setTarget(e.currentTarget.name)
        setLoading(true);
        // await dispatch(setFormOpenState(false, undefined));
        dispatch(setRecipeDetails(recipeId));
        dispatch(fetchIngredientListItemsByRecipe(recipeId));
        setTimeout(() => {
            setLoading(false);
        }, 1000)
    }

    async function deleteSelectedRecipe(e: SyntheticEvent<HTMLButtonElement>, recipeId: string){
        var targetRecipe: Recipe | undefined = recipes.find(r => r.recipeId === recipeId);
        await setTarget(e.currentTarget.name)
        await setSubmitting(true);
        await dispatch(deleteRecipe(recipeId));
        // await setTimeout(() => {
        //     setSubmitting(false);
        // }, 1000)
        if(targetRecipe && !recipes.includes(targetRecipe)){
            setSubmitting(false);
        }
    }

    return(
        <Segment>
            <Item.Group divided>
                {recipes.map((recipe) => (
                    <Item key={recipe.recipeId}>
                        <Item.Content>
                            <Item.Header as='a'>{recipe.name}</Item.Header>
                            <Item.Description>
                                <div>{recipe.description}</div>
                                <div>{recipe.instructions}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button as={Link} to={`/recipes/${recipe.recipeId}`} 
                                    onClick={(e) => setRecipeToShow(e, recipe.recipeId)}
                                    name={recipe.recipeId}
                                    loading={loading && target === recipe.recipeId.toString()}
                                    floated='right' 
                                    content='View' 
                                    color='green' />
                                <Button 
                                    name={recipe.recipeId}
                                    onClick={(e) => deleteSelectedRecipe(e, recipe.recipeId)} 
                                    loading={submitting && target === recipe.recipeId.toString()}
                                    floated='right' 
                                    content='Delete' 
                                    color='orange' 
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

export default RecipeList;