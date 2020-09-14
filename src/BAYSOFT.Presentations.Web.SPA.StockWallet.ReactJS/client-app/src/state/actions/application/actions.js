﻿import {
    APPLICATION_NAME_SET,
    APPLICATION_MENU_OPEN,
    APPLICATION_MENU_CLOSE,
    APPLICATION_NOTIFICATION_ADD,
    APPLICATION_NOTIFICATION_SHOW,
    APPLICATION_NOTIFICATION_CLOSE
} from './types';

const ApplicationNameSet = (name) => ({
    type: APPLICATION_NAME_SET,
    payload: {
        applicationName: name
    }
});
const ApplicationMenuOpen = () => ({
    type: APPLICATION_MENU_OPEN,
    payload: {
        isOpen: true
    }
});
const ApplicationMenuClose = () => ({
    type: APPLICATION_MENU_CLOSE,
    payload: {
        isOpen: false
    }
});
const ApplicationNotificatioAdd = (severity, message, autoClose) => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { snackBar } = ApplicationState.application;

    let notification = { severity, message, autoClose };
    if (snackBar.notifications.length === 0 && !snackBar.open) {
        dispatch(ApplicationNotificatioShow(notification));
    } else {
        dispatch({ type: APPLICATION_NOTIFICATION_ADD, payload: { notification: notification } });
    }
};
const ApplicationNotificatioShow = (notification) => (dispatch, getState) => {
    dispatch({ type: APPLICATION_NOTIFICATION_SHOW, payload: { notification: notification } });
};
const ApplicationNotificatioClose = () => (dispatch, getState) => {
    dispatch({ type: APPLICATION_NOTIFICATION_CLOSE, payload: {} });
};

export {
    ApplicationNameSet,
    ApplicationMenuOpen,
    ApplicationMenuClose,
    ApplicationNotificatioAdd,
    ApplicationNotificatioShow,
    ApplicationNotificatioClose
};