'use client'

import ProfileForm from '~widgets/profile-form'

import { BreadcrumbsTitle } from '~packages/ui'

export default function ProfilePage() {
	return (
		<>
			<BreadcrumbsTitle title={'Настройки'} />
			<ProfileForm />
		</>
	)
}
