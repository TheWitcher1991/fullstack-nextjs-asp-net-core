'use client'

import { ChevronRight } from '@gravity-ui/icons'
import {
	Breadcrumbs,
	BreadcrumbsItem,
	FirstDisplayedItemsCount,
	Flex,
	LastDisplayedItemsCount,
	Text,
} from '@gravity-ui/uikit'

import styles from './index.module.scss'

interface BreadcrumbsTitleProps {
	title: string
	items?: BreadcrumbsItem[]
}

export function BreadcrumbsTitle({ title, items }: BreadcrumbsTitleProps) {
	return (
		<Flex
			alignItems={'center'}
			justifyContent={'space-between'}
			className={styles.breadcrumbs}
		>
			<Text variant={'header-1'}>{title}</Text>
			{items && (
				<Breadcrumbs
					items={[
						{
							text: 'Главная',
							action: () => {},
						},
						...items,
					]}
					renderItemDivider={() => <ChevronRight />}
					firstDisplayedItemsCount={FirstDisplayedItemsCount.One}
					lastDisplayedItemsCount={LastDisplayedItemsCount.One}
				/>
			)}
		</Flex>
	)
}
