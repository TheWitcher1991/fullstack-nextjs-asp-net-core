'use client'

import ProfileForm from '~widgets/profile-form'

import { IAccount, useProfile } from '~models/account'

import { RenderFetchData } from '~packages/lib'
import { BreadcrumbsTitle } from '~packages/ui'

import ProfileLoading from './loading'

export default function ProfilePage() {
	const { isLoading, data } = useProfile()

	return (
		<>
			<BreadcrumbsTitle title={'Настройки'} />
			<RenderFetchData
				isLoading={isLoading}
				loadingFallback={<ProfileLoading />}
			>
				<ProfileForm profile={data?.data as IAccount} />
			</RenderFetchData>
		</>
	)
}
