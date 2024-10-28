import './App.css'
import {RouterProvider} from "react-router-dom";
import browserRoute from "@/routes";

function App() {

    return (
        <RouterProvider router={browserRoute}/>
    )
}

export default App
