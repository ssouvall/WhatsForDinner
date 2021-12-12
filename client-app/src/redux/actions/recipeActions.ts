import {
    FETCH_RECIPES,
    NEW_RECIPE
} from '../actions/types';
import { Dispatch } from 'redux';
import agent from '../../app/api/agent';
import { Recipe } from '../../app/models/recipe';

export const fetchRecipes = () => (dispatch: Dispatch) => {
    agent.Recipes.list()
    .then(response => {
        dispatch({
            type: FETCH_RECIPES,
            payload: response
        })
    })
}

export const createRecipe = (recipeData: Recipe) => (dispatch: Dispatch) => {
    agent.Recipes.create(recipeData).then(response => {
        dispatch({
            type: NEW_RECIPE,
            payload: response
        })
    })
}