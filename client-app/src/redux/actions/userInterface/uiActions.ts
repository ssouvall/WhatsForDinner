import {
   LOADING_INITIAL,
   SET_BUTTON_SUBMITTING_STATE
} from './uiTypes';
import { Dispatch } from 'redux';

export const setLoading = (state: boolean) => (dispatch: Dispatch) => {
    dispatch({
        type: LOADING_INITIAL,
        payload: state
    })
}

export const setButtonSubmittingState = (submitting: boolean) => (dispatch: Dispatch) => {
    dispatch({
        type: SET_BUTTON_SUBMITTING_STATE,
        submitting: submitting
    })
}