import { ApplicationActionType } from '../../actions';

const INITIAL_STATE = {
    application: {
        name: "[DEV]StockWallet",
        menu: {
            title: 'Menu',
            isOpen: true,
            items: [{
                name: 'Home',
                route: '/',
                isDisabled: false
            }, {
                name: 'Samples',
                route: '/samples',
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
        },
        snackBar: {
            open: false,
            severity: 'info',
            message: 'Oh, nevermind...',
            autoClose: true,
            notifications: [],
        }
    }
};
const ChangeStateApplicationNameSet = (state, payload) => {
    return { ...state, application: { ...state.application, name: payload.name } };
};
const ChangeStateApplicationMenuOpen = (state, payload) => {
    return { ...state, application: { ...state.application, menu: { ...state.application.menu, isOpen: payload.isOpen } } };
};
const ChangeStateApplicationMenuClose = (state, payload) => {
    return { ...state, application: { ...state.application, menu: { ...state.application.menu, isOpen: payload.isOpen } } };
};
const ChangeStateApplicationNotificationAdd = (state, payload) => {
    return { ...state, application: { ...state.application, snackBar: { ...state.snackBar, notifications: [...state.snackBar.notifications, payload.notification] } } };
};
const ChangeStateApplicationNotificationShow = (state, payload) => {
    let newSnackBar = { ...state.application.snackBar, open: true, severity: payload.notification.severity, message: payload.notification.message, autoClose: payload.notification.autoClose };
    return { ...state, application: { ...state.application, snackBar: { ...newSnackBar } } };
};
const ChangeStateApplicationNotificationClose = (state, payload) => {
    let newNotifications = [...state.application.snackBar.notifications ];
    newNotifications.shift();
    return { ...state, application: { ...state.application, snackBar: { ...state.snackBar, open: false, notifications: [...newNotifications] } } };
};
export const ApplicationReducer = (state = INITIAL_STATE, action) => {
    console.log(action.type);
    console.log(action.payload);
    switch (action.type) {
        case ApplicationActionType.types.APPLICATION_NAME_SET: return ChangeStateApplicationNameSet(state, action.payload);
        case ApplicationActionType.types.APPLICATION_MENU_OPEN: return ChangeStateApplicationMenuOpen(state, action.payload);
        case ApplicationActionType.types.APPLICATION_MENU_CLOSE: return ChangeStateApplicationMenuClose(state, action.payload);
        case ApplicationActionType.types.APPLICATION_NOTIFICATION_ADD: return ChangeStateApplicationNotificationAdd(state, action.payload);
        case ApplicationActionType.types.APPLICATION_NOTIFICATION_SHOW: return ChangeStateApplicationNotificationShow(state, action.payload);
        case ApplicationActionType.types.APPLICATION_NOTIFICATION_CLOSE: return ChangeStateApplicationNotificationClose(state, action.payload);
        default: return state;
    }
}