import { del, get, postJson, put } from "@/utils/fetch";

const prefix = '/api/v1/chat';

/**
 * 获取会话列表
 * @param keyword 
 * @returns 
 */
export const getSession = async (keyword: string) => {
    return get(`${prefix}/sessions?keyword=${keyword}`);
}

/**
 * 添加分组
 * @param data 
 * @returns 
 */
export const addSessionGroup = async (data: any) => {
    return postJson(`${prefix}/sessions`, data);
}

/**
 * 删除分组
 * @param id 
 * @returns 
 */
export const deleteSessionGroup = async (id: string) => {
    return del(`${prefix}/sessions/${id}`);
}

/**
 * 重命名分组
 * @param id  
 * @returns 
 */
export const renameSession = async (id: string, name: string) => {
    return put(`${prefix}/sessions/${id}?name=${name}`);
};

export const addSession = async (groupId: string, data: any) => {
    return postJson(`${prefix}/${groupId}/sessions`, data);
}

export const deleteSession = async (sessionId: string) => {
    return del(`${prefix}/sessions/session/${sessionId}`);
}

