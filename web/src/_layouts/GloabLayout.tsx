import {Outlet} from "react-router-dom";
import {ThemeProvider} from "@lobehub/ui";

export default function GlobalLayout(): JSX.Element {
    return (<ThemeProvider>
        <Outlet/>
    </ThemeProvider>)
}