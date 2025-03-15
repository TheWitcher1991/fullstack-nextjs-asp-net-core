import { Card, Text } from '@gravity-ui/uikit'

import { IBook } from '~models/book'

import { STATIC_URL } from '~packages/system'
import { CardImage, Spacing } from '~packages/ui'
import { trimText } from '~packages/utils'

import styles from './index.module.scss'

interface BookCardProps {
	book: IBook
}

export function BookCard({ book }: BookCardProps) {
	return (
		<Card className={styles.book__card} size='l' view={'filled'}>
			<CardImage
				src={`${STATIC_URL}${book.imagePath}`}
				width={187}
				height={247}
			/>
			<Spacing v={'xs'} />
			<Text variant={'body-2'} color={'hint'}>
				{trimText(book.author, 23)}
			</Text>
			<div></div>
			<Text variant={'body-2'}>{trimText(book.holder, 49)}</Text>
		</Card>
	)
}
