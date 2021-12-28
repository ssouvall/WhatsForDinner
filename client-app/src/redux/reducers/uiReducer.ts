import {
    LOADING_INITIAL
} from '../actions/userInterface/uiTypes'

interface uiAction {
    type: string;
    payload: any;
}

interface uiState {
    loading: boolean;
}

const initialState: uiState = {
    loading: false
}

export default function reducer(state = initialState, action: uiAction) {
    switch (action.type) {
        case LOADING_INITIAL:
            return {
                ...state,
                loading: action.payload
            }
        default:
            return state;
    }
}