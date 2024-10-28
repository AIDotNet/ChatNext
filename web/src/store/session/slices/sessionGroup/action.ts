import { SessionGroupItem } from "@/types/session";
import { SessionGroupsDispatch } from "./reducer";
import { StateCreator } from 'zustand/vanilla';
import { SessionStore } from '@/store/session';


export interface SessionGroupAction {
    addSessionGroup: (name: string) => Promise<string>;
    clearSessionGroups: () => Promise<void>;
    removeSessionGroup: (id: string) => Promise<void>;
    updateSessionGroupName: (id: string, name: string) => Promise<void>;
    updateSessionGroupSort: (items: SessionGroupItem[]) => Promise<void>;
    internal_dispatchSessionGroups: (payload: SessionGroupsDispatch) => void;
}


export const createSessionGroupSlice: StateCreator<
    SessionStore,
    [['zustand/devtools', never]],
    [],
    SessionGroupAction
> = (set, get) => ({

});
