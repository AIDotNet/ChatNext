import {createBrowserRouter, RouteObject} from "react-router-dom";
import GlobalLayout from "@/_layouts/GloabLayout";
import MainLayout from "@/app/layout.tsx";
import WelcomeLayout from "@/app/welcome";


const routes = [
    {
        element: <GlobalLayout/>,
        children: [
            {
                path: '',
                element: <MainLayout>
                    <WelcomeLayout/>
                </MainLayout>
            }
        ]
    }
] as RouteObject[];

const browserRoute = createBrowserRouter(routes);


export default browserRoute;