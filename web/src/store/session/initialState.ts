import { SessionState, initialSessionState } from './slices/session/initialState';
import { SessionGroupState, initSessionGroupState } from './slices/sessionGroup/initialState';

import { SessionDefaultGroup } from '@/types/session';

export interface SessionStoreState extends SessionGroupState, SessionState { }

export const initialState: SessionStoreState = {
    ...initSessionGroupState,
    ...initialSessionState,
};

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
    expandSessionGroupKeys: [SessionDefaultGroup.Pinned, SessionDefaultGroup.Default],
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
