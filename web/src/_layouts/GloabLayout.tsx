import { Outlet } from "react-router-dom";
import { ThemeProvider } from "@lobehub/ui";
import { useGlobalStore } from "@/store/global";
import { NuqsAdapter } from "nuqs/adapters/react";

export default function GlobalLayout(): JSX.Element {
    const [theme, currentTheme] = useGlobalStore((s) => [s.theme, s.currentTheme]);

    return (<ThemeProvider
        themeMode={theme}
        onThemeModeChange={(mode) => {
            currentTheme(mode);
        }}
        style={{
            height: '100%',
        }}>
        <NuqsAdapter>
            <Outlet />
        </NuqsAdapter>
    </ThemeProvider>)
}