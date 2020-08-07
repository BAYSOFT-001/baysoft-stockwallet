import { ApplicationActionType } from '../../actions';

const INITIAL_STATE = {
    application: {
        name: "StockWallet"
    }
};

export const ApplicationReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case ApplicationActionType.types.SET_APPLICATION_NAME: return {
            ...state,
            application: {
                ...state.application,
                name: action.payload.name
            }
        };
        default: return state;
    }
}