'use client'

import { PersonPlus } from '@gravity-ui/icons'
import { Button, Icon, PasswordInput, TextInput } from '@gravity-ui/uikit'
import { zodResolver } from '@hookform/resolvers/zod'
import { useRouter } from 'next/navigation'
import { useForm } from 'react-hook-form'

import { ILogin, IRegister, RegisterSchema, useLogin } from '~models/account'

import { query } from '~packages/lib'
import links from '~packages/links'
import { FormCard, FormLink, FormSection, Spacing } from '~packages/ui'

export default function RegisterForm() {
	const router = useRouter()
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<IRegister>({
		defaultValues: {
			email: '',
			phone: '',
			password: '',
			firstName: '',
			lastName: '',
		},
		resolver: zodResolver(RegisterSchema),
	})
	const req = useLogin()

	const onSubmit = async (data: ILogin) => {
		await query(async () => {
			await req.mutateAsync(data)
			router.push(links.login)
		})
	}

	return (
		<FormCard title={'Присоединиться к Строкам'} width={400}>
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

				<FormSection label={'Телефон'}>
					<TextInput
						type={'text'}
						error={errors.phone?.message}
						errorMessage={errors.phone?.message}
						size={'xl'}
						placeholder={'+7'}
						{...register('phone')}
					/>
				</FormSection>

				<FormSection label={'Фамилия'}>
					<TextInput
						type={'text'}
						error={errors.lastName?.message}
						errorMessage={errors.lastName?.message}
						size={'xl'}
						{...register('lastName')}
					/>
				</FormSection>

				<FormSection label={'Имя'}>
					<TextInput
						type={'text'}
						error={errors.firstName?.message}
						errorMessage={errors.firstName?.message}
						size={'xl'}
						{...register('firstName')}
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
					<Icon size={18} data={PersonPlus} />
					Продолжить
				</Button>

				<Spacing />
				<FormLink href={links.login}>Есть аккаунт?</FormLink>
			</form>
		</FormCard>
	)
}
