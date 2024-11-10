
export enum SidebarTabKey {
    Chat = 'chat',
    Market = 'market',
    Me = 'me',
    Setting = 'settings',
    Welcome = '',
    File = 'file',
}



export enum ChatSettingsTabs {
    Chat = 'chat',
    Meta = 'meta',
    Modal = 'modal',
    Plugin = 'plugin',
    Prompt = 'prompt',
}


export interface GlobalState {
    hasNewVersion?: boolean;
    isMobile?: boolean;
    isStatusInit?: boolean;
    latestVersion?: string;
    router?: any;
    sidebarKey: SidebarTabKey;
    status: SystemStatus;
    statusStorage: any;
    theme: 'auto' | 'light' | 'dark';
}

export enum SettingsTabs {
    About = 'about',
    Agent = 'agent',
    Common = 'common',
    LLM = 'llm',
    SystemAgent = 'system-agent',
}

export interface SystemStatus {
    // which sessionGroup should expand
    expandSessionGroupKeys: string[];
    filePanelWidth: number;
    hidePWAInstaller?: boolean;
    inputHeight: number;
    mobileShowPortal?: boolean;
    mobileShowTopic?: boolean;
    sessionsWidth: number;
    showChatSideBar?: boolean;
    showFilePanel?: boolean;
    showSessionPanel?: boolean;
    showSystemRole?: boolean;
    zenMode?: boolean;
}

export const INITIAL_STATUS = {
    expandSessionGroupKeys: ['pinned', 'default'],
    filePanelWidth: 320,
    hidePWAInstaller: false,
    inputHeight: 200,
    mobileShowTopic: false,
    sessionsWidth: 320,
    showChatSideBar: true,
    showFilePanel: true,
    showSessionPanel: true,
    showSystemRole: false,
    zenMode: false,
} satisfies SystemStatus;

export const initialState: GlobalState = {
    isMobile: false,
    isStatusInit: false,
    sidebarKey: SidebarTabKey.Chat,
    status: INITIAL_STATUS,
    statusStorage: undefined,
    theme: localStorage.getItem('theme') as 'auto' | 'light' | 'dark' ?? 'auto',
};
