import {
    DELETE_RECIPE,
    EDIT_RECIPE,
    FETCH_RECIPES,
    GET_SELECTED_RECIPE,
    SET_SELECTED_RECIPE,
    NEW_RECIPE
} from './recipeTypes';
import { Dispatch } from 'redux';
import agent from '../../../app/api/agent';
import { Recipe } from '../../../app/models/recipe';

export const fetchRecipes = () => (dispatch: Dispatch) => {
    agent.Recipes.list()
    .then(response => {
        dispatch({
            type: FETCH_RECIPES,
            payload: response
        })
    })
}

export const setRecipeDetails = (recipeId: number) => (dispatch: Dispatch) => {
    agent.Recipes.details(recipeId).then(response => {
        dispatch({
            type: SET_SELECTED_RECIPE,
            payload: response
        })
    })
}

export const getRecipeDetails = (recipeId: number) => (dispatch: Dispatch) => {
    agent.Recipes.details(recipeId).then(response => {
        dispatch({
            type: GET_SELECTED_RECIPE,
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

export const editRecipe = (recipeData: Recipe) => (dispatch: Dispatch) => {
    agent.Recipes.update(recipeData).then(response => {
        dispatch({
            type: EDIT_RECIPE,
            payload: response
        })
    })
}

export const deleteRecipe = (recipeId: number) => (dispatch: Dispatch) => {
    agent.Recipes.delete(recipeId).then(response => {
        dispatch({
            type: DELETE_RECIPE,
            payload: response
        })
    })
}