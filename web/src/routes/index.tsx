import { createBrowserRouter, RouteObject } from "react-router-dom";
import GlobalLayout from "@/_layouts/GloabLayout";
import MainLayout from "@/app/layout.tsx";
import WelcomeLayout from "@/app/welcome";
import ChatLayout from "@/app/(main)/chat";
import LoginPage from "@/app/login";


const routes = [
    {
        element: <GlobalLayout />,
        children: [
            {
                path: '',
                element: <MainLayout>
                    <WelcomeLayout />
                </MainLayout>
            },
            {
                path: 'chat',
                element: <MainLayout>
                    <ChatLayout />
                </MainLayout>
            },
            {
                path: 'login',
                element: <LoginPage />
            }
        ]
    }
] as RouteObject[];

const browserRoute = createBrowserRouter(routes);


export default browserRoute;