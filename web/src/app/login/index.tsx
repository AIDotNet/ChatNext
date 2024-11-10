import { memo, useState } from 'react';
import { message, Input, Button } from 'antd';
import { EyeInvisibleOutlined, EyeTwoTone, } from '@ant-design/icons';
import { GridShowcase } from '@lobehub/ui';
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';
import { Token } from '@/services/AuthorizationService';

const FunctionTools = styled.div`
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
    cursor: pointer;
    justify-content: center;
    align-items: center;
    text-align: center;
    margin: 0 auto;
    width: 380px;
    margin-top: 20px;
    color: #0366d6;
`;

const Login = memo(() => {
    const navigate = useNavigate();

    const [loading, setLoading] = useState(false);
    const [user, setUser] = useState('');
    const [password, setPassword] = useState('');

    async function handleLogin() {

        try {
            setLoading(true);
            const result = await Token({
                username: user,
                password: password,
            });
            if (result.code === "200") {
                localStorage.setItem('token', result.data);
                navigate('/');
            } else {
                message.error(result.message);
            }

        } catch (e) {

        }
        setLoading(false);
    }


    return (
        <GridShowcase>
            <div style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                margin: '0 auto',
                width: '100%',
                height: '100%',
                justifyContent: 'center',
                textAlign: 'center',

            }}>
                <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', margin: '0 auto', width: '380px', marginBottom: '20px' }}>
                    <div style={{ textAlign: 'center', marginBottom: '20px' }}>
                        <span style={{
                            fontSize: '28px',
                            fontWeight: 'bold',
                            marginBottom: '20px',
                            display: 'block',

                        }}>
                            Chat Next 登录
                        </span>
                    </div>
                    <div style={{ marginBottom: '20px', width: '100%' }}>
                        <Input
                            value={user}
                            onChange={(e) => setUser(e.target.value)}
                            size='large'
                            placeholder="请输入账号" />
                    </div>
                    <div style={{ width: '100%' }}></div>
                    <Input.Password
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        size='large'
                        placeholder="请输入密码"
                        // 按下回车键
                        onPressEnter={async () => {
                            await handleLogin();
                        }}
                        iconRender={visible => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)}
                    />
                </div>
                <div style={{
                    marginBottom: '20px',
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    width: '380px',
                    marginTop: '20px',
                }}>
                    <Button
                        loading={loading}
                        onClick={async () => {
                            await handleLogin();
                        }}
                        size='large'
                        type="primary"
                        block >
                        登录
                    </Button>
                </div>
                <FunctionTools>
                    <span onClick={() => {
                        if (typeof window === 'undefined') return;
                        window.location.href = '/register';
                    }}>
                        注册账号
                    </span>
                </FunctionTools>
            </div>
        </GridShowcase>
    );
});

export default Login;