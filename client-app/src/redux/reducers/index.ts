import {
    combineReducers
} from 'redux';
import recipeReducer from './recipeReducer';
import ingredientReducer from './ingredientReducer';
import uiReducer from '../reducers/uiReducer'

export default combineReducers({
    recipes: recipeReducer,
    ingredients: ingredientReducer,
    ui: uiReducer
});