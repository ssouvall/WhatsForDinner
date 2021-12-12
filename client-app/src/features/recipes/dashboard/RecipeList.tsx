import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from "../../../redux/store";
import { useEffect } from "react";
import { fetchRecipes } from '../../../redux/actions/recipeActions';

interface Props {
    selectRecipe: (id: number) => void;
    deleteRecipe: (id: number) => void;
    submitting: boolean;
}

function RecipeList({selectRecipe, deleteRecipe, submitting}: Props) {
    const dispatch = useDispatch()
    const recipes: Recipe[] = useSelector((state: RootState) => state.recipes.recipes)

    useEffect(() => {
        fetchRecipes();
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
                                <Button onClick={() => selectRecipe(recipe.id)} floated='right' content='View' color='blue' />
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