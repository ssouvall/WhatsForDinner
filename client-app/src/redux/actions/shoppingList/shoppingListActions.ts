import {
   ADD_RECIPES_TO_SHOPPINGLIST
} from './shoppingListTypes';
import { Dispatch } from 'redux';
import agent from '../../../app/api/agent';

export const addRecipesToList = (shoppinglistId: string, recipesToAdd: string[]) => (dispatch: Dispatch) => {
    recipesToAdd.forEach((r) => {
        agent.ShoppingLists.addRecipesToList(shoppinglistId, r).then(response => {
            dispatch({
                type: ADD_RECIPES_TO_SHOPPINGLIST,
                payload: response
            })
        })
    })
}