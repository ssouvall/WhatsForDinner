import React, { useEffect, useState } from "react";
import { Grid} from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import RecipeDetails from "../details/RecipeDetails";
import RecipeForm from "../form/RecipeForm";
import RecipeList from "./RecipeList";
import LoadingComponent from '../../../app/layout/LoadingComponents';
import { useDispatch, useSelector } from 'react-redux';
import { fetchRecipes } from '../../../redux/actions/recipe/recipeActions';
import { RootState } from "../../../redux/store";

export default function RecipeDashboard(){
    const selectedRecipe: Recipe | undefined = useSelector((state: RootState) => state.recipes.recipe)
    const editMode: boolean = useSelector((state: RootState) => state.recipes.editMode)
    const[recipes,setRecipes] = useState<Recipe[]>([]);
    const [loading, setLoading] = useState(true);
    const dispatch = useDispatch()
    const allRecipes: Recipe[] = useSelector((state: RootState) => state.recipes.recipes)

    useEffect(() => {
      function loadRecipeData(){
        return new Promise ((resolve, reject) => {
          resolve(dispatch(fetchRecipes()));
          reject('There was an error loading the data');
        })
      }
      loadRecipeData().then(data => {
        setTimeout(() => {
          setRecipes(data as Recipe[]);
          setLoading(false);
        }, 1000)
      })
    }, [dispatch, allRecipes])
  
    if (loading) return <LoadingComponent content='Loading app' />

    return (
        <Grid>
            <Grid.Column width='10'>
                <RecipeList />
            </Grid.Column>
            <Grid.Column width='6'>
            {selectedRecipe && selectedRecipe.id !== 0 && !editMode &&
                <RecipeDetails 
                    recipe={selectedRecipe}
                /> }
                {editMode &&
                <RecipeForm/>}                
            </Grid.Column>
        </Grid>
    )
}