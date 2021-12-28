import {
    combineReducers
} from 'redux';
import recipeReducer from './recipeReducer';
import uiReducer from '../reducers/uiReducer'

export default combineReducers({
    recipes: recipeReducer,
    ui: uiReducer
});