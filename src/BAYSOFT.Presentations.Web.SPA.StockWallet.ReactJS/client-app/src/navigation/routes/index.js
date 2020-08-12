import {
    Pages,
} from '../../components/pages';

const DEFAULT_ROUTE = { private: false, name: "DEFAULT", path: "/", params: [], component: Pages.Home.Index }
const HOME_ROUTE = { private: false, name: "HOME", path: "/home", params: [], component: Pages.Home.Index }
//const SIGNIN_ROUTE = { private: false, name: "SIGNIN", path: "/signin", params: [], component: SignInScreen }
//const OTHER_ROUTE = { private: false, name: "OTHER", path: "/other/:id", params: ['id'], component: OtherScreen }
//const NOTFOUND_ROUTE = { private: false, name: 'NOTFOUND', path: '/*', params: [], component: ErrorScreen }

const ROUTES = [
    DEFAULT_ROUTE,
    HOME_ROUTE,
    //OTHER_ROUTE,
    //SIGNIN_ROUTE,
    //NOTFOUND_ROUTE,
];

export default ROUTES;