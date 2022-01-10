import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from "../../../redux/store";
import { useState, SyntheticEvent } from "react";
import { deleteRecipe, setFormOpenState, setRecipeDetails } from '../../../redux/actions/recipe/recipeActions';
import { Link } from "react-router-dom";

function RecipeList() {
    const dispatch = useDispatch()
    const [submitting, setSubmitting] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState('');
    const recipes: Recipe[] = useSelector((state: RootState) => state.recipes.recipes)

    async function setRecipeToShow(e: SyntheticEvent<HTMLButtonElement>, recipeId: number){
        console.log(e.currentTarget)
        await setTarget(e.currentTarget.name)
        await setLoading(true);
        await dispatch(setFormOpenState(false, undefined));
        await dispatch(setRecipeDetails(recipeId));
        await setTimeout(() => {
            setLoading(false);
        }, 1000)
    }

    async function deleteSelectedRecipe(e: SyntheticEvent<HTMLButtonElement>, recipeId: number){
        var targetRecipe: Recipe | undefined = recipes.find(r => r.id === recipeId);
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
                    <Item key={recipe.id}>
                        <Item.Content>
                            <Item.Header as='a'>{recipe.name}</Item.Header>
                            <Item.Description>
                                <div>{recipe.description}</div>
                                <div>{recipe.instructions}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button as={Link} to={`/recipes/${recipe.id}`} 
                                    onClick={(e) => setRecipeToShow(e, recipe.id)}
                                    name={recipe.id}
                                    loading={loading && target === recipe.id.toString()}
                                    floated='right' 
                                    content='View' 
                                    color='blue' />
                                <Button 
                                    name={recipe.id}
                                    onClick={(e) => deleteSelectedRecipe(e, recipe.id)} 
                                    loading={submitting && target === recipe.id.toString()}
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

// const mapStateToProps = (state: RootState) => ({
//     recipes: state.recipes.recipes
// })

export default RecipeList;