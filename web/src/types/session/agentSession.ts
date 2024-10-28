
import { MetaData } from '../meta';
import { SessionGroupId } from './sessionGroup';

export enum LobeSessionType {
    Agent = 'agent',
    Group = 'group',
}

/**
 * Token Agent
 */
export interface LobeAgentSession {
    createdAt: Date;
    group?: SessionGroupId;
    meta: MetaData;
    model: string;
    tags?: string[];
    updatedAt: Date;
    id: number;
    groupId: string;
    pinned: boolean;
    type: string | null;
    config: { [key: string]: any; };
    avatar: string;
    description: string;
    title: string;
    provider: string;
    systemRole: string;
    topP: number;
    temperature: number;
    presencePenalty: number;
    historyLimit: number;
    plugins: string[];
}

export type LobeSessions = LobeAgentSession[];
