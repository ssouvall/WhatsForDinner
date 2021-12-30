import React from "react";
import { Grid} from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import RecipeDetails from "../details/RecipeDetails";
import RecipeForm from "../form/RecipeForm";
import RecipeList from "./RecipeList";
import { useSelector } from 'react-redux';
import { RootState } from "../../../redux/store";

interface Props {
    // selectedRecipe: Recipe | undefined;
    selectRecipe: (id: number) => void;
    cancelSelectRecipe: () => void;
    openForm: (id: number) => void;
    closeForm: () => void;
    // editMode: boolean;
    createOrEdit: (recipe: Recipe) => void;
    deleteRecipe: (id: number) => void;
    submitting: boolean;
}

export default function RecipeDashboard({/*selectedRecipe, */selectRecipe, cancelSelectRecipe, openForm, closeForm,/* editMode,*/ createOrEdit, submitting, deleteRecipe}: Props){
    const selectedRecipe: Recipe | undefined = useSelector((state: RootState) => state.recipes.recipe)
    const editMode: boolean = useSelector((state: RootState) => state.recipes.editMode)

    return (
        <Grid>
            <Grid.Column width='10'>
                <RecipeList 
                    // selectRecipe={selectRecipe}
                    deleteRecipe={deleteRecipe}
                    submitting={submitting}
                />
            </Grid.Column>
            <Grid.Column width='6'>
            {selectedRecipe && selectedRecipe.id !== 0 && !editMode &&
                <RecipeDetails 
                    recipe={selectedRecipe}
                    cancelSelectRecipe={cancelSelectRecipe}
                    openForm={openForm}
                /> }
                {editMode &&
                <RecipeForm 
                    closeForm={closeForm}
                    recipe={selectedRecipe}
                    createOrEdit={createOrEdit}
                    submitting={submitting}
                />}                
            </Grid.Column>
        </Grid>
    )
}