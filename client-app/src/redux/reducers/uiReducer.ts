import {
    LOADING_INITIAL,
    SET_BUTTON_SUBMITTING_STATE
} from '../actions/userInterface/uiTypes'

interface uiAction {
    type: string;
    payload: any;
}

interface uiState {
    loading: boolean;
    submitting: boolean;
}

const initialState: uiState = {
    loading: false,
    submitting: false
}

export default function reducer(state = initialState, action: uiAction) {
    switch (action.type) {
        case LOADING_INITIAL:
            return {
                ...state,
                loading: action.payload
            }
        case SET_BUTTON_SUBMITTING_STATE:
            return {
                ...state,
                submitting: action.payload
            }
        default:
            return state;
    }
}