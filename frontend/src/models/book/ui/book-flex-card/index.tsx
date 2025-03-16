'use client'

import { Card, Label, Text } from '@gravity-ui/uikit'
import { useRouter } from 'next/navigation'

import { IBook } from '~models/book'

import links from '~packages/links'
import { STATIC_URL } from '~packages/system'
import { CardImage, Spacing } from '~packages/ui'
import { trimText } from '~packages/utils'

import styles from './index.module.scss'

interface BookFlexCardProps {
	book: IBook
}

export function BookFlexCard({ book }: BookFlexCardProps) {
	const router = useRouter()

	return (
		<Card
			className={styles.book__flex__card}
			view={'outlined'}
			type={'selection'}
			onClick={() => router.replace(links.books.byId(book.id))}
		>
			<CardImage
				src={`${STATIC_URL}${book.imagePath}`}
				width={76}
				radius={4}
				height={114}
			/>
			<div>
				<Text variant={'body-2'} color={'secondary'}>
					{trimText(book.author.fullName, 23)}
				</Text>
				<div></div>
				<Text variant={'body-2'}>{trimText(book.title, 49)}</Text>
				<Spacing v={'xss'} />
				<Label theme={'clear'} size={'xs'}>
					{book.age}+
				</Label>
			</div>
		</Card>
	)
}
