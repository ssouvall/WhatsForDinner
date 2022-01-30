import React from "react";
import { Grid} from "semantic-ui-react";
import IngredientForm from "../form/IngredientForm";
import IngredientList from "./IngredientList";

function IngredientDashboard(){
    return(
        <Grid>
            <Grid.Column width='10'>
                <IngredientList />
            </Grid.Column>
            <Grid.Column width='6'>
                <h2>Recipe Filters</h2>
                <IngredientForm />
            </Grid.Column>
        </Grid>
    )
}

export default IngredientDashboard;