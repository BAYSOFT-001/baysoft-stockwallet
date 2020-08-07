import { SET_APPLICATION_NAME } from './types';

const SetApplicationName = (name) => ({
    type: SET_APPLICATION_NAME,
    payload: {
        applicationName: name
    }
});

export { SetApplicationName };