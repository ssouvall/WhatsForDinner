import {
   LOADING_INITIAL
} from './uiTypes';
import { Dispatch } from 'redux';

export const setLoading = (state: boolean) => (dispatch: Dispatch) => {
    dispatch({
        type: LOADING_INITIAL,
        payload: state
    })
}