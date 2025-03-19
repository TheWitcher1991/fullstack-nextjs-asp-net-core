'use client'

import { Card, Label, Text } from '@gravity-ui/uikit'
import { useRouter } from 'next/navigation'

import { IBook } from '~models/book'

import links from '~packages/links'
import { CardImage, Spacing } from '~packages/ui'
import { staticPath, trimText } from '~packages/utils'

import styles from './index.module.scss'

interface BookCardProps {
	book: IBook
}

export function BookCard({ book }: BookCardProps) {
	const router = useRouter()

	return (
		<Card
			className={styles.book__card}
			type={'selection'}
			view={'filled'}
			onClick={() => router.push(links.books.byId(book.id))}
		>
			<CardImage
				src={staticPath(book.imagePath)}
				width={175}
				height={275}
			/>
			<Spacing v={'xs'} />
			<Text variant={'body-2'} color={'secondary'}>
				{trimText(book.author.fullName, 23)}
			</Text>
			<div></div>
			<Text variant={'body-2'}>{trimText(book.title, 49)}</Text>
			{book.age >= 18 && (
				<>
					<Spacing v={'xss'} />
					<Label theme={'clear'} size={'xs'}>
						{book.age}+
					</Label>
				</>
			)}
		</Card>
	)
}
