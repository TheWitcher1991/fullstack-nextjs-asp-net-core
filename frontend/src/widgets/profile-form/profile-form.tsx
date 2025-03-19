'use client'

import { CloudCheck } from '@gravity-ui/icons'
import { Button, Icon, TextInput } from '@gravity-ui/uikit'
import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import toast from 'react-hot-toast'

import {
	IAccount,
	IUpdateAccount,
	UpdateAccountSchema,
	useUpdateAccount,
} from '~models/account'

import { query } from '~packages/lib'
import { FormCard, FormSection, Spacing } from '~packages/ui'

interface ProfileFormProps {
	profile: IAccount
}

export default function ProfileForm({ profile }: ProfileFormProps) {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<IUpdateAccount>({
		defaultValues: {
			email: profile?.email,
			firstName: profile?.firstName,
			lastName: profile?.lastName,
			phone: profile?.phone,
		},
		resolver: zodResolver(UpdateAccountSchema),
	})
	const req = useUpdateAccount()

	const onSubmit = async (data: IUpdateAccount) => {
		await query(async () => {
			await req.mutateAsync(data)
			toast.success('Профиль обновлен')
		})
	}

	return (
		<FormCard title={'Профиль'} width={'100%'}>
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

				<Spacing />
				<Button
					view={'action'}
					size={'l'}
					type={'submit'}
					loading={req.isPending}
				>
					<Icon size={18} data={CloudCheck} />
					Сохранить
				</Button>
			</form>
		</FormCard>
	)
}
