import {
    combineReducers
} from 'redux';
import recipeReducer from './recipeReducer';
import ingredientReducer from './ingredientReducer';
import ingredientListItemsReducer from './ingredientListItemReducer';
import uiReducer from '../reducers/uiReducer'

export default combineReducers({
    recipes: recipeReducer,
    ingredients: ingredientReducer,
    ingredientListItems: ingredientListItemsReducer,
    ui: uiReducer
});