import { ApplicationActionType } from '../../actions';

const INITIAL_STATE = {
    application: {
        name: "StockWallet",
        menu: {
            title: 'Menu',
            isOpen: true,
            items: [{
                name: 'Home',
                route: '/',
                isDisabled: false
            }, {
                name: 'Item 01',
                route: '/item-01',
                isDisabled: false
            }, {
                name: 'Item 02',
                route: '/item-02',
                isDisabled: true
            }]
        }
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
        case ApplicationActionType.types.APPLICATION_MENU_OPEN: return {
            ...state,
            application: {
                ...state.application,
                menu: {
                    ...state.application.menu,
                    isOpen: action.payload.isOpen
                }
            }
        };
        case ApplicationActionType.types.APPLICATION_MENU_CLOSE: return {
            ...state,
            application: {
                ...state.application,
                menu: {
                    ...state.application.menu,
                    isOpen: action.payload.isOpen
                }
            }
        };
        default: return state;
    }
}