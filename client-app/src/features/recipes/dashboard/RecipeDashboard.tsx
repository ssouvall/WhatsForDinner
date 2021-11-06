import React from "react";
import { Grid} from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import RecipeList from "./RecipeList";

interface Props {
    recipes: Recipe[];
}

export default function RecipeDashboard({recipes}: Props){
    
    return (
        <Grid>
            <Grid.Column width='10'>
                <RecipeList 
                    recipes={recipes}
                />
            </Grid.Column>
        </Grid>
    )
}