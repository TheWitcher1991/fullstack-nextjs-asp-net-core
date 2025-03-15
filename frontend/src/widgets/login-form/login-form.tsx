'use client'

import { ArrowRightToSquare } from '@gravity-ui/icons'
import { Button, Icon, PasswordInput, TextInput } from '@gravity-ui/uikit'
import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'

import { ILogin, login, LoginSchema, useLogin } from '~models/account'

import { query } from '~packages/lib'
import links from '~packages/links'
import { FormCard, FormLink, FormSection, Spacing } from '~packages/ui'

export default function LoginForm() {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<ILogin>({
		defaultValues: {
			email: '',
			password: '',
		},
		resolver: zodResolver(LoginSchema),
	})
	const req = useLogin()

	const onSubmit = async (data: ILogin) => {
		await query(async () => {
			const res = await req.mutateAsync(data)
			login(res.data.result.account)
			window.location.replace(links.books.index)
		})
	}

	return (
		<FormCard title={'Вход в Строки'} width={400}>
			<form onSubmit={handleSubmit(onSubmit)}>
				<FormSection label={'Email'}>
					<TextInput
						type={'email'}
						error={errors.email?.message}
						errorMessage={errors.email?.message}
						size={'xl'}
						{...register('email')}
					/>
				</FormSection>

				<FormSection label={'Пароль'}>
					<PasswordInput
						size={'xl'}
						error={errors.password?.message}
						errorMessage={errors.password?.message}
						{...register('password')}
					/>
				</FormSection>

				<Spacing />

				<Button
					view={'action'}
					size={'xl'}
					type={'submit'}
					loading={req.isPending}
					width={'max'}
				>
					<Icon size={18} data={ArrowRightToSquare} />
					Открыть строки
				</Button>

				<Spacing />
				<FormLink href={links.register}>Нет аккаунта?</FormLink>
			</form>
		</FormCard>
	)
}
