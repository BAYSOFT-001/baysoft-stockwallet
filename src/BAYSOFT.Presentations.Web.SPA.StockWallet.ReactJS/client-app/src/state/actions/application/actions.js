import {
    APPLICATION_NAME_SET,
    APPLICATION_MENU_OPEN,
    APPLICATION_MENU_CLOSE
} from './types';

const SetApplicationName = (name) => ({
    type: APPLICATION_NAME_SET,
    payload: {
        applicationName: name
    }
});

export { SetApplicationName };

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

export { ApplicationMenuOpen, ApplicationMenuClose };