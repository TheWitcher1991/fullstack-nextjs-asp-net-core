import { Flex, Text } from '@gravity-ui/uikit'
import { FC, PropsWithChildren } from 'react'

import { Spacing } from '~packages/ui'

interface FormSectionProps extends PropsWithChildren {
	label: string
	withOutMargin?: boolean
}

export const FormSection: FC<FormSectionProps> = ({
	label,
	children,
	withOutMargin,
}) => {
	return (
		<Flex width={'100%'} direction={'column'}>
			<Text variant={'body-1'} color={'secondary'}>
				{label}
			</Text>
			<Spacing v={'xs'} />
			{children}
			{!withOutMargin && <Spacing />}
		</Flex>
	)
}
