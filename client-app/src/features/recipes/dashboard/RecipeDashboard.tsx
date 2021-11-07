import React from "react";
import { Grid} from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import RecipeDetails from "../details/RecipeDetails";
import RecipeList from "./RecipeList";

interface Props {
    recipes: Recipe[];
    selectedRecipe: Recipe | undefined;
    selectRecipe: (id: number) => void;
    cancelSelectRecipe: () => void;
}

export default function RecipeDashboard({recipes, selectedRecipe, selectRecipe, cancelSelectRecipe}: Props){
    
    return (
        <Grid>
            <Grid.Column width='10'>
                <RecipeList 
                    recipes={recipes}
                    selectRecipe={selectRecipe}
                />
            </Grid.Column>
            <Grid.Column width='6'>
                {selectedRecipe &&
                <RecipeDetails 
                    recipe={selectedRecipe}
                    cancelSelectRecipe={cancelSelectRecipe}
                /> }
            </Grid.Column>
        </Grid>
    )
}