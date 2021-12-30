import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from "../../../redux/store";
import { useEffect } from "react";
import { fetchRecipes, setFormOpenState, setRecipeDetails } from '../../../redux/actions/recipe/recipeActions';

interface Props {
    // selectRecipe: (id: number) => void;
    deleteRecipe: (id: number) => void;
    submitting: boolean;
}

function RecipeList({/*selectRecipe,*/ deleteRecipe, submitting}: Props) {
    const dispatch = useDispatch()
    const recipes: Recipe[] = useSelector((state: RootState) => state.recipes.recipes)

    function setRecipeToShow(recipeId: number){
        dispatch(setFormOpenState(false, undefined))
        dispatch(setRecipeDetails(recipeId))
    }
    useEffect(() => {
        dispatch(fetchRecipes());
    }, [dispatch])

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
                                <Button onClick={() => setRecipeToShow(recipe.id)} floated='right' content='View' color='blue' />
                                <Button 
                                    onClick={() => deleteRecipe(recipe.id)} 
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