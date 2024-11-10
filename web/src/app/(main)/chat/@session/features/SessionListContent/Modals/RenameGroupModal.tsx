import { Input, Modal, type ModalProps } from '@lobehub/ui';
import { App } from 'antd';
import isEqual from 'fast-deep-equal';
import { memo, useState } from 'react';

import { useSessionStore } from '@/store/session';
import { sessionGroupSelectors } from '@/store/session/selectors';

interface RenameGroupModalProps extends ModalProps {
  id: string;
}

const RenameGroupModal = memo<RenameGroupModalProps>(({ id, open, onCancel }) => {

  const updateSessionGroupName = useSessionStore((s) => s.updateSessionGroupName);
  const group = useSessionStore((s) => sessionGroupSelectors.getGroupById(id)(s), isEqual);

  const [input, setInput] = useState<string>();
  const [loading, setLoading] = useState(false);

  const { message } = App.useApp();
  return (
    <Modal
      allowFullscreen
      destroyOnClose
      okButtonProps={{ loading }}
      onCancel={(e) => {
        setInput(group?.name);
        onCancel?.(e);
      }}
      onOk={async (e) => {
        if (!input) return;
        if (input.length === 0 || input.length > 20)
          return message.warning('分组名称长度应在 1-20 个字符之间');
        setLoading(true);
        await updateSessionGroupName(id, input);
        message.success('重命名成功');
        setLoading(false);

        onCancel?.(e);
      }}
      open={open}
      title={'智能重命名'}
      width={400}
    >
      <Input
        autoFocus
        defaultValue={group?.name}
        onChange={(e) => setInput(e.target.value)}
        placeholder={'请输入分组名称...'}
        value={input}
      />
    </Modal>
  );
});

export default RenameGroupModal;
