import { Bookmark, BookmarkFill } from '@gravity-ui/icons'
import { Button, Icon } from '@gravity-ui/uikit'
import { useState } from 'react'
import toast from 'react-hot-toast'

import { IBook } from '~models/book'

interface BookFavoriteButtonProps {
	book: IBook
}

const buttonStyle = {
	borderRadius: 99,
	overflow: 'hidden',
}

export default function BookOFavoriteButton({ book }: BookFavoriteButtonProps) {
	const [isFavorite, setIsFavorite] = useState<boolean>(book.isFavorite)

	const onClick = () => {
		setIsFavorite(!isFavorite)
		book.isFavorite = !book.isFavorite
		isFavorite
			? toast.success('Убрано из избранного')
			: toast.success('Добавлено в избранное')
	}

	return (
		<Button
			size={'xl'}
			onlyIcon={true}
			style={buttonStyle}
			onClick={onClick}
		>
			<Icon data={isFavorite ? BookmarkFill : Bookmark} size={18} />
		</Button>
	)
}
